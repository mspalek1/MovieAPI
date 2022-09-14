using System;

namespace Domain.Data
{
    [Flags]
    public enum MovieCategory
    {
        Action = 1,
        Comedy = 2,
        Drama = 4,
        Horror = 8,
        Musical = 64
    }
}
