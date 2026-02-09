using App.Base.Infrastructure.Services;
using App.Base.Shared.Models;
using Microsoft.EntityFrameworkCore;
using App.Base.Infrastructure.Storage.Db.EF.Interceptors.Implementations;
using App.Base.Infrastructure.Storage.Db.EF.Interceptors;

namespace App.Modules.KW_TEMPLATE.Infrastructure.Storage.Db.Interceptions.Instances
{

    /// <summary>
    /// 
    /// <para>
    /// Invoked when the Request is wrapping up, 
    /// and invokes <c>IUnitOfWorkService</c>'s 
    /// commit operation, 
    /// which in turn invokes each DbContext's SaveChanges, 
    /// which are individually overridden, to in turn 
    /// invoke <see cref="IDbContextPreCommitService"/>
    /// which invokes 
    /// all PreCommitProcessingStrategy implementations, such 
    /// as this.
    /// </para>
    /// </summary>
    /// <seealso cref="DbContextPreCommitProcessingStrategyBase{IHasInRecordAuditability}" />
    public class
        KW_TEMPLATEDbContextPreCommitStrategy 
            : IDbCommitPreCommitProcessingStrategy
        //where T : class
        //    DbContextPreCommitProcessingStrategyBase
        //        <IHasInRecordAuditability>
    {
        /// <summary>
        /// Constructor.
        /// <para>
        /// Invoked by <c>IDbContextPreCommitService</c>,
        /// when it is invoked by the App's base 
        /// DbContext, in the override of the OnSave method.
        /// </para>
        /// <para>
        /// Used to update attributes of entities that implement
        /// a specific Interface.
        /// </para>
        /// </summary>
        public KW_TEMPLATEDbContextPreCommitStrategy()
            //IUniversalDateTimeService dateTimeService,
            //IPrincipalService principalService)
            //: base(dateTimeService, principalService, 
            //      EntityState.Added,
            //    EntityState.Modified, 
            //    EntityState.Deleted)
        {

        }
/// <inheritdoc/>

        public bool Enabled { get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); }
/// <inheritdoc/>

        public Type InterfaceType => throw new NotImplementedException();
/// <inheritdoc/>

        public EntityState[] States => throw new NotImplementedException();
/// <inheritdoc/>

        public void Process(DbContext dbContext)
        {
            throw new NotImplementedException();
        }


        ///// <summary>
        ///// 
        ///// <para>
        ///// Invoked by <c>IDbContextPreCommitService</c>
        ///// when it is invoked by the App's base 
        ///// DbContext, in the override of the OnSave method.
        ///// /// </para>
        ///// <para>
        ///// Used to update attributes of entities that implement
        ///// a specific Interface.
        ///// </para>
        ///// <para>
        ///// Implemenation note:ensure the argument type matches 
        ///// the T of the class.
        ///// </para>
        ///// </summary>
        ///// <param name="entity"></param>
        //protected override void PreProcessEntity(IHasInRecordAuditability entity)
        //{
        //    // You can look at the entity's attributes
        //    // and change them.
        //}
    }
}