// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Threading;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Base class for observable objects viewmodels
    /// </summary>
    public abstract class ObservableObject 
        : INotifyPropertyChanged
    {
        #region · Static Methods ·

        public static PropertyChangedEventArgs CreateArgs<T>(
            Expression<Func<T, object>> propertyExpression)
        {
            return new PropertyChangedEventArgs(propertyExpression.GetPropertyName());
        }

        #endregion

        #region · INotifyPropertyChanged Members ·

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region · Fields ·

        private Dispatcher dispatcher;

        #endregion

        #region · Protected Properties ·

        protected Dispatcher Dispatcher
        {
            get { return this.dispatcher; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableObject"/> class.
        /// </summary>
        protected ObservableObject()
        {
            this.dispatcher = Dispatcher.CurrentDispatcher;
        }

        #endregion

        #region · Protected Methods ·

        /// <summary>
        /// Executes the specified <see cref="Action "/> at the <see cref="DispatcherPriority.ApplicationIdle"/> priority 
        /// on the thread on which the DispatcherObject is associated with. 
        /// </summary>
        /// <param name="dispatcherObject">The dispatcher object.</param>
        /// <param name="action">The action.</param>
        protected void InvokeAsynchronously(Action action)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        /// <summary>
        /// Executes the specified <see cref="Action "/> at the <see cref="DispatcherPriority.ApplicationIdle"/> priority 
        /// on the thread on which the DispatcherObject is associated with. 
        /// </summary>
        /// <param name="dispatcherObject">The dispatcher object.</param>
        /// <param name="action">The action.</param>
        protected void InvokeAsynchronouslyInBackground(Action action)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, action);
        }

        /// <summary>
        /// Executes the specified <see cref="Action "/> at the <see cref="DispatcherPriority.ApplicationIdle"/> priority 
        /// on the thread on which the DispatcherObject is associated with. 
        /// </summary>
        /// <param name="dispatcherObject">The dispatcher object.</param>
        /// <param name="action">The action.</param>
        protected void Invoke(Action action)
        {
            if (this.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                this.Dispatcher.Invoke(action);
            }
        }

        /// <summary>
        /// Notifies all properties changed.
        /// </summary>
        protected void NotifyAllPropertiesChanged()
        {
            this.NotifyPropertyChanged((string)null);
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The property.</param>
        protected virtual void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            this.NotifyPropertyChanged(property.CreateChangeEventArgs());
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            this.NotifyPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.InvokeAsynchronouslyInBackground
                (
                    () =>
                    {
                        this.PropertyChanged(this, args);
                    }
                );
            }
        }

        #endregion
    }
}
