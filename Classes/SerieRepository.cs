//using DIO.Series.Interfaces;

namespace DIO.Series;

public class SerieRepository : IRepository<Serie>
{
    private List<Serie> listseries = new List<Serie>();
    public void Update(int id, Serie entity)
    {
        listseries[id] = entity;
    }

    public void Delete(int id)
    {
        listseries[id].Delete();
    }

    public void Insert(Serie entity)
    {
        listseries.Add(entity);
    }

    public List<Serie> SeriesList()
    {
        return listseries;
    }

    public int NextId()
    {
        return listseries.Count;
    }

    public Serie ReturnById(int id)
    {
        return listseries[id];
    }
}