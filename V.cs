using System;

namespace pobrify
{
    static class V
    {
        public static bool VerifyId(int id)
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
