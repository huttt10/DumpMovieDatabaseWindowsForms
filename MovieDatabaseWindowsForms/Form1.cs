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

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {            
            if(textBox.Text != "")
            {
                string[] strlist = GetFormatString(textBox.Text);

                Movie movie = new Movie {
                    Name = strlist[0],
                    Director = strlist[1],
                    Year = int.Parse(strlist[2]),
                    Score = int.Parse(strlist[3]),
                    BestRanking = int.Parse(strlist[4]),
                    PopularRanking = int.Parse(strlist[5]),
                    Seen = bool.Parse(strlist[6])
                };

                dbContext.Add(movie);
                dbContext.SaveChanges();
                PopulateDataGridView();
                Clear();
            }
        }

        private string[] GetFormatString(string ToFormat)
        {
            string[] retString = ToFormat.Split(',');

            if (retString.Last() == "Ano")
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
            dataGridView.DataSource = dbContext.Movies.ToList<Movie>();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dbContext.Movies.Count<Movie>() != 0)
            {
                Movie movie = dbContext.Movies.FirstOrDefault(movie => movie.Id == Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value));
                dbContext.Update(movie);
                dbContext.SaveChanges();

                Clear();
                PopulateDataGridView();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(dbContext.Movies.Count<Movie>() != 0)
            {
                Movie movie = dbContext.Movies.FirstOrDefault(movie => movie.Id == Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value));            
                dbContext.Movies.Remove(movie);
                dbContext.SaveChanges();

                Clear();
                PopulateDataGridView();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                      
            var neco = dbContext.Movies.FirstOrDefault(movie => movie.Id == e.RowIndex);
            textBox.Text = Convert.ToString(neco);
        }

        private void Clear()
        {
            textBox.Text = "";
        }
    }
}