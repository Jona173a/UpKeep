﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UpKeepProject.Data.Base
{
    public abstract class DomainClassBase<T> : IDomainClass
        where T : class
    {
        public const int NullId = -1;
        public abstract int GetId();
        public abstract void SetId(int id);
        public abstract void CopyValuesFromObj(T obj);

        protected DomainClassBase()
        {
            SetInitialValues();
        }

        public IDomainClass Copy()
        {
            return (MemberwiseClone() as IDomainClass);
        }

        public void CopyValuesFrom(IDomainClass obj)
        {
            T tObj = (obj as T);
            CopyValuesFromObj(tObj);
        }

        public virtual void SetInitialValues()
        {
        }

        public static int IdOrNullId(int? id)
        {
            return id ?? NullId;
        }
    }
}
