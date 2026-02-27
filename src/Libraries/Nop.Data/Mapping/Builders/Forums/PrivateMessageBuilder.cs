using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Data.Extensions;
using ForumPrivateMessage = Nop.Core.Domain.Forums.PrivateMessage;

namespace Nop.Data.Mapping.Builders.Forums;

/// <summary>
/// Represents a private message entity builder
/// </summary>
public partial class PrivateMessageBuilder : NopEntityBuilder<ForumPrivateMessage>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ForumPrivateMessage.Subject)).AsString(450).NotNullable()
            .WithColumn(nameof(ForumPrivateMessage.Text)).AsString(int.MaxValue).NotNullable()
            .WithColumn(nameof(ForumPrivateMessage.FromCustomerId)).AsInt32().ForeignKey<Customer>().OnDelete(Rule.None)
            .WithColumn(nameof(ForumPrivateMessage.ToCustomerId)).AsInt32().ForeignKey<Customer>().OnDelete(Rule.None);
    }

    #endregion
}