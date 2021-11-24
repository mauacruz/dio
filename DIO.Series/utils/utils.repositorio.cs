namespace DIO.Series{
  using System.Collections.Generic;

  public sealed class SerieRepository: ISerieRepository{
    private SerieRepository() { }
    private static SerieRepository _instance;
    private static List<ISerie> _serieList;

    public static SerieRepository GetInstance (){
      if (_instance == null) { 
        _instance = new SerieRepository();
        _serieList = new List<ISerie>();
        
      }
      return _instance;
    }
                  
    public bool Save(ISerie value){
      _serieList.Add(value);
      return true;
    }   
  }

}  