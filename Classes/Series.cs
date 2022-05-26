namespace DIO.Series
{
    public class Serie : BaseEntities
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Deleted: " + this.Deleted;
            return retorno;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }
        public int ReturnId()
        {
            return this.Id;
        }
        public bool ReturnDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}