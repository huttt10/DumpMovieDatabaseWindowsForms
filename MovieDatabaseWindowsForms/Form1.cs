using MovieDatabaseWindowsForms.Data;
using MovieDatabaseWindowsForms.Model;

namespace MovieDatabaseWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ApplicationDbContext dbContext = new ApplicationDbContext();
        FaktoryOnMovie factoryOnMovie = new FaktoryOnMovie();

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                string[] strlist = GetFormatString(textBox.Text);

                Movie movie = factoryOnMovie.CreateMovie(strlist);

                dbContext.Add(movie);
                dbContext.SaveChanges();
                PopulateDataGridView();
                Clear();
            }
        }

        private string[] GetFormatString(string ToFormat)
        {
            string[] retString = ToFormat.Split(',');

            if (retString.Last() == "Ano" || retString.Last() == "True")
            {
                retString[retString.Length - 1] = "True";
            }
            else
            {
                retString[retString.Length - 1] = "False";
            }

            return retString;
        }

        public void PopulateDataGridView()
        {
            dataGridView.DataSource = dbContext.Movies.OrderBy(x => x.BestRanking).ToList<Movie>();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dbContext.Movies.Count<Movie>() != 0)
            {
                Movie oldMovie = dbContext.Movies.FirstOrDefault(movie => movie.Id == Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value));

                string[] strlist = GetFormatString(textBox.Text);                
                Movie newMovie = factoryOnMovie.CreateMovie(strlist);

                dbContext.Remove(oldMovie);
                dbContext.Movies.Add(newMovie);
                dbContext.SaveChanges();

                Clear();
                PopulateDataGridView();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dbContext.Movies.Count<Movie>() != 0)
            {
                Movie movie = dbContext.Movies.FirstOrDefault(movie => movie.Id == Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value));
                dbContext.Movies.Remove(movie);
                dbContext.SaveChanges();

                Clear();
                PopulateDataGridView();
            }
        }

        private void Clear()
        {
            textBox.Text = "";
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clear();
            var id = dataGridView.Rows[e.RowIndex].Cells[0].Value;
            var movie = dbContext.Movies.FirstOrDefault(m => m.Id == int.Parse(id.ToString()));
            textBox.Text = Convert.ToString(movie);
        }
    }

    class FaktoryOnMovie
    {
        public Movie CreateMovie(string[] strlist)
        {
            Movie movie = new Movie() {
                
                Name = strlist[0],
                Director = strlist[1],
                Year = int.Parse(strlist[2]),
                Score = int.Parse(strlist[3]),
                BestRanking = int.Parse(strlist[4]),
                PopularRanking = int.Parse(strlist[5]),
                Seen = bool.Parse(strlist[6])
            };
            return movie;
        }
    }
}