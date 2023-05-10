using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;

namespace todolist.domain.persistence
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static void Initialize(string configFilePath)
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure("hibernate.cfg.xml");
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        public static string getFullPath(string fileName)
        {
            var assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            return Path.Combine(assemblyDirectory, fileName);
        }
    }
}