using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExt
{
    public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer renderer)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(@this);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    public static bool IsRenderedFrom(Renderer aRenderer, Camera aCam)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(aCam);
        for (int i = 0; i < planes.Length; i++)
            planes[i].Flip();
        return !GeometryUtility.TestPlanesAABB(planes, aRenderer.bounds);
    }
}
