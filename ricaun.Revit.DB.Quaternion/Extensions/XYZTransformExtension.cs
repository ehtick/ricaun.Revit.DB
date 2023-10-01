using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Quaternion.Extensions
{
    /// <summary>
    /// XYZTransformExtension
    /// </summary>
    public static class XYZTransformExtension
    {
        /// <summary>
        /// Transform
        /// </summary>
        /// <param name="value"></param>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static XYZ Transform(this XYZ value, Quaternion quaternion)
        {
            return quaternion.Transform(value);
        }

        /// <summary>
        /// Transform <paramref name="value"/> with <paramref name="quaternion"/> and add <paramref name="origin"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="quaternion"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static XYZ Transform(this XYZ value, Quaternion quaternion, XYZ origin)
        {
            return quaternion.Transform(value) + origin;
        }
    }

}
