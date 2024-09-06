﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StudentCourseFluentMVCApp.Mappings;

namespace StudentCourseFluentMVCApp.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISession CreateSession()
        {
            if (_sessionFactory == null)
            {

                _sessionFactory = Fluently.Configure().
                    Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                    .BuildSessionFactory();

            }

            return _sessionFactory.OpenSession();
        }
    }
}