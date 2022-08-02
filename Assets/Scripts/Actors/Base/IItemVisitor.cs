using Actors.Items;

namespace Actors.Base
{
	public interface IItemVisitor
	{
		public void ItemVisit(BigHeart heart);
	}
}