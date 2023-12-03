namespace Spotify.Extensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> items)
        {
            Random rand = new Random();
            for (int i = 0; i < items.Count - 1; i++)
            {
                int pos = rand.Next(i, items.Count);
                (items[i], items[pos]) = (items[pos], items[i]);
            }
        }

        public static void ShuffleAndSetFirst<T>(this IList<T> items, int firstItemIndex)
        {
            Random rand = new Random();

            if (firstItemIndex >= 0 && firstItemIndex < items.Count)
            {
                (items[0], items[firstItemIndex]) = (items[firstItemIndex], items[0]);
            }

            for (int i = 1; i < items.Count - 1; i++)
            {
                int pos = rand.Next(i, items.Count);
                (items[i], items[pos]) = (items[pos], items[i]);
            }
        }
    }
}
