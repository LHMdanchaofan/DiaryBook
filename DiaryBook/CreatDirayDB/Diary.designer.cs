﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreatDirayDB
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	public partial class DiaryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertDiary(Diary instance);
    partial void UpdateDiary(Diary instance);
    partial void DeleteDiary(Diary instance);
    #endregion
		
		public DiaryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DiaryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DiaryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DiaryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Diary> Diary
		{
			get
			{
				return this.GetTable<Diary>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Diary : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _title;
		
		private string _content;
		
		private string _time;
		
		private string _weather;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OncontentChanging(string value);
    partial void OncontentChanged();
    partial void OntimeChanging(string value);
    partial void OntimeChanged();
    partial void OnweatherChanging(string value);
    partial void OnweatherChanged();
    #endregion
		
		public Diary()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_content", CanBeNull=false)]
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				if ((this._content != value))
				{
					this.OncontentChanging(value);
					this.SendPropertyChanging();
					this._content = value;
					this.SendPropertyChanged("content");
					this.OncontentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time", CanBeNull=false)]
		public string time
		{
			get
			{
				return this._time;
			}
			set
			{
				if ((this._time != value))
				{
					this.OntimeChanging(value);
					this.SendPropertyChanging();
					this._time = value;
					this.SendPropertyChanged("time");
					this.OntimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_weather", CanBeNull=false)]
		public string weather
		{
			get
			{
				return this._weather;
			}
			set
			{
				if ((this._weather != value))
				{
					this.OnweatherChanging(value);
					this.SendPropertyChanging();
					this._weather = value;
					this.SendPropertyChanged("weather");
					this.OnweatherChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
