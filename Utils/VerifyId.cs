using System;

namespace pobrify
{
    static class VerifyId
    {
        public static bool Verify(int id)
        {
            if (id < 0)
            {
                return false;
                throw new ArgumentOutOfRangeException("ID não deve ser menor que 1!", nameof(id));
            }
            return true;
        }
    }
}
