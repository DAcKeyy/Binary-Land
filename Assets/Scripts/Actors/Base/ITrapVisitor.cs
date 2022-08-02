using Actors.Items;

namespace Actors.Base
{
	public interface ITrapVisitor
	{
		public void TrapVisit(SpiderWeb web);
	}
}