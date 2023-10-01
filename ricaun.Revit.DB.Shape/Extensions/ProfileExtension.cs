using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// ProfileExtension
    /// </summary>
    public static class ProfileExtension
    {
        /// <summary>
        /// Creates a new Profile which is the transformation of the input Profile.
        /// </summary>
        /// <param name="profile">The profile to be transformed.</param>
        /// <param name="transform">The transform (which must be conformal).</param>
        /// <returns></returns>
        public static Profile CreateTransformed(this Profile profile, Transform transform)
        {
            return profile.get_Transformed(transform);
        }
    }
}
