using System;

namespace Domain.Data
{
    [Flags]
    public enum MovieCategory
    {
        Action = 0,
        Comedy = 2,
        Drama = 4,
        Horror = 8,
        Musical = 64
    }
}
