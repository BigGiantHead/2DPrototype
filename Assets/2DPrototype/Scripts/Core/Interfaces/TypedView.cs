using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Abstract class that represents a view that binds to a type of context.
    /// </summary>
    /// <typeparam name="T">Type of the context that this view binds to.</typeparam>
    public abstract class TypedView<T> : MonoBehaviour, IView where T: class
    {
        /// <summary>
        /// The Game that this View will use.
        /// </summary>
        [Dependency]
        public IGame Game { get; set; }

        /// <summary>
        /// If the view should be automatically bound to the context on Start.
        /// This is used in case you want to bind the view in code, and not with current context.
        /// </summary>
        public bool AutoBind = true;

        protected virtual void Start()
        {
            //inject dependencies
            this.Inject();

            //autobind to current context.
            if (AutoBind)
            {
                BindToContext(Game.CurrentContext);
            }
        }
        
        public void BindToContext(object context)
        {
            BindToContext(context as T);
        }

        /// <summary>
        /// Bind the view to context of type T.
        /// </summary>
        /// <param name="context">The context of type T.</param>
        public abstract void BindToContext(T context);
    }
}
