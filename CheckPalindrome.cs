using CodeSignal;

namespace CodeSignal
{
    public class CheckPalindrome
    {
        internal int accessCount;

        public int MyProperty { get; set; }

        public virtual void IncreaseCount()
        {
            accessCount++;
        }
    }

}

namespace MyNamespace
{
    public class CheckPalindrome1 : CheckPalindrome
    {
        public void Test()
        {
            this.accessCount = 0;
        }

        public override void IncreaseCount()
        {
            base.IncreaseCount();
        }
    }

}