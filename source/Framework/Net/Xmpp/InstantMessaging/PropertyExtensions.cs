// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Property Extension Methods
    /// </summary>
    /// <remarks>
    /// http://reyntjes.blogspot.com/2009/04/master-detail-viewmodel_24.html
    /// http://blogs.ugidotnet.org/bmatte/archive/2008/11/28/pattern-model-view-viewmodel-inotifypropertychanged-static-reflection-e-extension-methods.aspx
    /// </remarks>
    public static class PropertyExtensions
    {
        #region · Extension Methods ·

        /// <summary>
        /// Creates a <see cref="PropertyChangedEventArgs" /> instance for a given property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static PropertyChangedEventArgs CreateChangeEventArgs<T>(this Expression<Func<T>> property)
        {
            var expression = property.Body as MemberExpression;
            var member = expression.Member;

            return new PropertyChangedEventArgs(member.Name);
        }

        /// <summary>
        /// Returns property name from expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(this Expression<Func<T>> property)
        {
            var expression = property.Body as MemberExpression;
            
            return expression.Member.Name;
        }

        /// <summary>
        /// Return property name from expression.
        /// </summary>
        /// <example>
        /// <![CDATA[
        ///     Expression<Func<Item, object>> expression = i => i.Name;
        ///     var propertyName = expression.GetPropertyName(); // propertyName = "Name"
        /// ]]>
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, TValue>(this Expression<Func<T, TValue>> expression)
        {
            var lambda = expression as LambdaExpression;

            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = lambda.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }

            return null;
        }

        #endregion
    }
}
