using Ocluse.LiquidSnow.Venus.Blazor.Components;

namespace Ocluse.LiquidSnow.Venus.Blazor
{
    public class ValidationSet
    {
        private readonly List<IValidatable> _items = new();

        public ValidationSet(params IValidatable?[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    _items.Add(item);
                }
            }
        }

        public async Task<bool> Validate()
        {
            List<bool> results = new();

            foreach (var item in _items)
            {
                if (item != null)
                {
                    var result = await item.InvokeValidate();
                    results.Add(result);
                }
            }

            return !results.Any() || results.All(x => x == true);
        }

        public void Add(params IValidatable?[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    _items.Add(item);
                }
            }
        }
    }
}
