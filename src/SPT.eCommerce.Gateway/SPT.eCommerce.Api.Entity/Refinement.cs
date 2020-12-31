using System;

namespace SPT.eCommerce.Api.Entity
{
    public class Refinement
    {
        public string Id { get; set; }
        public string  Title { get; set; }
        public RefinementValue Value { get; set; }
    }

    public class RefinementValue
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}