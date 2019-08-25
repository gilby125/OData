using maskx.OData.Metadata;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;

namespace maskx.OData
{
    public interface IDataSource
    {
        Configuration Configuration { get; set; }
        string Name { get; }
        EdmModel Model { get; }

        EdmEntityObjectCollection Get(ODataQueryOptions queryOptions);
        long GetCount(ODataQueryOptions queryOptions);
        EdmEntityObject Get(string key, ODataQueryOptions queryOptions);
        /// <summary>
        /// insert one row to table
        /// </summary>
        /// <param name="entity">the data of the row</param>
        /// <returns>the identity of the new recorder</returns>
        string Create(IEdmEntityObject entity);
        int Delete(string key, IEdmType elementType);
        int Merge(string key, IEdmEntityObject entity);
        int Replace(string key, IEdmEntityObject entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="parameterValues"></param>
        /// <param name="queryOptions"></param>
        /// <returns></returns>
        IEdmObject InvokeFunction(ODataQueryOptions queryOptions);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="parameterValues"></param>
        /// <param name="queryOptions"></param>
        /// <returns></returns>
        int GetFuncResultCount(ODataQueryOptions queryOptions);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        IEdmObject DoAction(IEdmAction action, JObject parameterValues);

        Action<RequestInfo> BeforeExcute { get; set; }
        Func<RequestInfo, object, object> AfrerExcute { get; set; }

        #region Meta data
        ConcurrentDictionary<string, Table> Tables { get; }
        ConcurrentDictionary<string, View> Views { get; }
        ConcurrentDictionary<string, StoredProcedure> StoredProcedures { get; }
        ConcurrentDictionary<string, Function> Functions { get; }
        ConcurrentDictionary<string, Relationship> Relationships { get; }
        IDataSource Table(string fullName, Action<Table> tableSetting);
        IDataSource View(string fullName, Action<View> viewSetting);
        IDataSource StoredProcedure(string fullName, Action<StoredProcedure> storedProcedureSetting);
        IDataSource Function(string fullName, Action<Function> functionSetting);
        IDataSource Relationship(string fullName, Action<Relationship> RelationshipSetting);
        /// <summary>
        /// Load  information from database
        /// </summary>
        /// <returns></returns>
        IDataSource LoadFromDatabase(MetadataType type);
        #endregion
    }
}
