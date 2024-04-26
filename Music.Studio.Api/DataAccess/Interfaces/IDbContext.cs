using System.Data.Common;

namespace Music.Studio.Api.DataAccess.Interfaces;

public interface IDbContext
{
     DbConnection Connection { get; }
}