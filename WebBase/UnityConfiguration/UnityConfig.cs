﻿using System;
using Microsoft.Practices.Unity;

namespace Cares.WebBase.UnityConfiguration
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container

// ReSharper disable InconsistentNaming
        private static IUnityContainer unityContainer;
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
        private readonly static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
// ReSharper restore InconsistentNaming
        {
            if (unityContainer == null)
            {
                unityContainer = new UnityContainer();
            }
            RegisterTypes(unityContainer);
            return unityContainer;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
