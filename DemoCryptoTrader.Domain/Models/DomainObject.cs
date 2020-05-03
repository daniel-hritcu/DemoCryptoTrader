using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    /*
     * This is a fix for the GenericDataService<T>.
     * 
     * When using 'where T : class' , CRUD operations that use Id can not be used
     * as it's not known if <T> has an Id field. 
     * 
     * We need to:
     *      Declare 'where T : DomainObject' in the GenericDataService
     *      Inherit the DomainObject in our models that have an Id.
     */
    public class DomainObject
    {
        public int Id { get; set; }
    }
}
