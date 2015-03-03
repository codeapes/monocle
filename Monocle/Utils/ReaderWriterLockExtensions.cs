// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using System.Threading;

namespace CodeApes.Monocle
{
    public static class ReaderWriterLockExtensions
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(2);

        public static void ExecuteWithWriteLock(this ReaderWriterLock rwLock, Action action)
        {
            rwLock.AcquireWriterLock(Timeout);
            try
            {
                action();
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
        }

        public static void ExecuteWithReadLock(this ReaderWriterLock rwLock, Action action)
        {
            rwLock.AcquireReaderLock(Timeout);
            try
            {
                action();
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }
        }
    }
}
