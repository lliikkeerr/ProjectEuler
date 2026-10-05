namespace ProjectEuler
{
    internal class Arrays
    {
        public int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] ans = new int[m + n];
            int i1 = 0;
            int i2 = 0;
            while (i1 < m & i2 < n)
            {
                if (nums1[i1] < nums2[i2])
                {
                    ans[i1 + i2] = nums1[i1];
                    i1++;
                }
                else
                {
                    ans[i1 + i2] = nums2[i2];
                    i2++;
                }
            }
            while (i1 < m)
            {
                ans[i1 + i2] = nums1[i1];
                i1++;
            }
            while (i2 < n)
            {
                ans[i1 + i2] = nums2[i2];
                i2++;
            }
            return ans;
        }
    }
}