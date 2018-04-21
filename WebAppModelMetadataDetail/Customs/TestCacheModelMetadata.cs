using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppModelMetadataDetail.Customs
{
    public class TestCachedModelMetadata<TPrototypeCache>
    {
        private string _dataTypeName;
        private bool _dataTypeNameComputed;

        protected virtual string ComputeDataTypeName()
        {
            return "TestModelMetadata";
        }

        public string DataTypeName
        {
            get
            {
                return TestCachedModelMetadata<TPrototypeCache>.CacheOrCompute<string>
                    (new Func<string>(this.ComputeDataTypeName),
                    ref this._dataTypeName,ref this._dataTypeNameComputed);
            }
            set
            {
                this._dataTypeName = value;
                this._dataTypeNameComputed = false;
            }
        }

        private static T CacheOrCompute<T>(Func<T> func, ref T _dataTypeName, ref bool _dataTypeNameComputed)
        {
            if (!_dataTypeNameComputed)
            {
                _dataTypeName = func();
                _dataTypeNameComputed = true;
            }
            return _dataTypeName;
        }
    }
}