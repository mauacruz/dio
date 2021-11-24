namespace DIO.Series
{
  public interface ISerie {
    ISerie Genero (Genero value);
    ISerie Titulo (string value);
    ISerie Descricao (string value);
    ISerie Ano (int value);
    bool Save();
  }

  public interface ISerieRepository{
    bool Save (ISerie value);    
  }
}