using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace LightSpeed_Expo.Models
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class Pelicula : Entity<int>
  {
    #region Fields
  
    private string _titulo;
    private string _descripcion;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Titulo entity attribute.</summary>
    public const string TituloField = "Titulo";
    /// <summary>Identifies the Descripcion entity attribute.</summary>
    public const string DescripcionField = "Descripcion";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Pelicula")]
    private readonly EntityCollection<Critica> _criticas = new EntityCollection<Critica>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Critica> Criticas
    {
      get { return Get(_criticas); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string Titulo
    {
      get { return Get(ref _titulo, "Titulo"); }
      set { Set(ref _titulo, value, "Titulo"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Descripcion
    {
      get { return Get(ref _descripcion, "Descripcion"); }
      set { Set(ref _descripcion, value, "Descripcion"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class Critica : Entity<int>
  {
    #region Fields
  
    private string _comentario;
    private string _critico;
    private int _peliculaId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Comentario entity attribute.</summary>
    public const string ComentarioField = "Comentario";
    /// <summary>Identifies the Critico entity attribute.</summary>
    public const string CriticoField = "Critico";
    /// <summary>Identifies the PeliculaId entity attribute.</summary>
    public const string PeliculaIdField = "PeliculaId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Criticas")]
    private readonly EntityHolder<Pelicula> _pelicula = new EntityHolder<Pelicula>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Pelicula Pelicula
    {
      get { return Get(_pelicula); }
      set { Set(_pelicula, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string Comentario
    {
      get { return Get(ref _comentario, "Comentario"); }
      set { Set(ref _comentario, value, "Comentario"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Critico
    {
      get { return Get(ref _critico, "Critico"); }
      set { Set(ref _critico, value, "Critico"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Pelicula" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public int PeliculaId
    {
      get { return Get(ref _peliculaId, "PeliculaId"); }
      set { Set(ref _peliculaId, value, "PeliculaId"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the LightSpeed_Expo model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class LightSpeed_ExpoUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<Pelicula> Peliculas
    {
      get { return this.Query<Pelicula>(); }
    }
    
    public System.Linq.IQueryable<Critica> Criticas
    {
      get { return this.Query<Critica>(); }
    }
    
  }

}
