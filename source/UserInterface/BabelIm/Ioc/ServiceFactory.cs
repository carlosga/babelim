using Autofac;
using BabelIm.Contracts;
using BabelIm.Net.Xmpp.InstantMessaging;
using System;
using System.Collections.Generic;

namespace BabelIm.IoC
{
    /// <summary>
    /// IServiceFactory implementation
    /// </summary>
    public sealed class ServiceFactory
        : IServiceFactory
    {
        #region · Singleton Instance ·

        private static readonly ServiceFactory Factory = new ServiceFactory();

        /// <summary>
        /// Current instance of ServiceFactory
        /// </summary>
        public static ServiceFactory Current
        {
            get { return Factory; }
        }

        /// <summary>
        /// Prevent "before field init" IL annotation
        /// </summary>
        static ServiceFactory()
        {
        }

        #endregion

        #region · Fields ·

        private IContainer container;

        #endregion

        #region · Constructors ·

        /// <summary>
        /// default constructor
        /// </summary>
        private ServiceFactory()
        {
			this.container = this.BuildContainer();
        }

        #endregion

        #region · IServiceFactory Members ·

        /// <summary>
        /// <see cref="M:Microsoft.Samples.NLayerApp.Infrastructure.CrossCutting.IoC.IServiceFactory.Resolve{TService}"/>
        /// </summary>
        /// <typeparam name="TService"><see cref="M:Microsoft.Samples.NLayerApp.Infrastructure.CrossCutting.IoC.IServiceFactory.Resolve{TService}"/></typeparam>
        /// <returns><see cref="M:Microsoft.Samples.NLayerApp.Infrastructure.CrossCutting.IoC.IServiceFactory.Resolve{TService}"/></returns>
        public TService Resolve<TService>()
        {
            return this.container.Resolve<TService>();
        }

        /// <summary>
        /// Solve type construction and return the object as a TService instance
        /// </summary>
        /// <typeparam name="TService">Type of dependency to return</typeparam>
        /// <param name="type">Real Type of dependency to instantiate</param>
        /// <returns>instance of TService</returns>
        public object Resolve(Type type)
        {
            return this.container.Resolve(type, null);
        }

        #endregion

        #region · Private Methods ·

        /// <summary>
        /// Configure root container.Register types and life time managers for unity builder process
        /// </summary>
        /// <param name="container">Container to configure</param>
        private IContainer BuildContainer()
        {
			var builder = new ContainerBuilder();
			 
			// Register individual components		
			builder.RegisterType<XmppSession>()
				   .As<IXmppSession>()
                   .SingleInstance();
			builder.RegisterType<ChatViewManager>()
				   .As<IChatViewManager>()
                   .SingleInstance();
			builder.RegisterType<ConfigurationManager>()
				   .As<IConfigurationManager>()
                   .SingleInstance();
			 
			return builder.Build();		
        }

        #endregion
    }
}
