﻿using System;
using System.Collections.Generic;

namespace DependencyInjection.Resolvers
{
    public sealed class ResolverDebugProperties
    {
        public int Resolutions;
        public List<(WeakReference, List<CallSite>)> Instances { get; } = new();
        public List<CallSite> BindingCallsite { get; } = new();
    }
}