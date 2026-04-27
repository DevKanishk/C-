using OnlineStore.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ApplicationCore.Services
{
    public class UriComposer : IUriComposer
    {
        private readonly CatalogSettings _catalogSettings;

        public UriComposer(CatalogSettings catalogSettings) 
        { 
            _catalogSettings = catalogSettings;
        }
        public string ComposePicUri(string UriTemplate)
        {
            return UriTemplate.Replace("http://catalogbaseurltobereplaced", _catalogSettings.CatalogBaseUrl);        
        }
    }
}   
