using AspireWebApp.Domain.Heroes;
using AspireWebApp.Domain.Teams;
using Vogen;

namespace AspireWebApp.Infrastructure.Persistence.Configuration;

[EfCoreConverter<TeamId>]
[EfCoreConverter<HeroId>]
[EfCoreConverter<MissionId>]
internal sealed partial class VogenEfCoreConverters;