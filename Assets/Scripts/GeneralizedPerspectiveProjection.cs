using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralizedPerspectiveProjection : MonoBehaviour
{
    [SerializeField]
    private Transform _pa = null;

    [SerializeField]
    private Transform _pb = null;

    [SerializeField]
    private Transform _pc = null;

    [SerializeField]
    private float _scale = 1f;

    private Transform _pe = null;
    private Camera _camera = null;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _pe = _camera.transform;
    }

    private void Update()
    {
        UpdateFrustrum();
    }

    private void UpdateFrustrum()
    {
        float n = _camera.nearClipPlane;
        float f = _camera.farClipPlane;

        Vector3 pa = _pa.position;
        Vector3 pb = _pb.position;
        Vector3 pc = _pc.position;
        Vector3 pe = _pe.position;

        // Compute an orthonormal basis for the screen.
        Vector3 vr = (pb - pa).normalized;
        Vector3 vu = (pc - pa).normalized;
        Vector3 vn = Vector3.Cross(vu, vr).normalized;

        // Compute the screen corner vectors.
        Vector3 va = pa - pe;
        Vector3 vb = pb - pe;
        Vector3 vc = pc - pe;

        // Find the distance from the eye to screen plane.
        float d = -Vector3.Dot(va, vn);

        // Find the extent of the perpendicular projection.
        float nd = n / d * _scale;
        float l = Vector3.Dot(vr, va) * nd;
        float r = Vector3.Dot(vr, vb) * nd;
        float b = Vector3.Dot(vu, va) * nd;
        float t = Vector3.Dot(vu, vc) * nd;

        // Load the perpendicular projection.
        Matrix4x4 P = Matrix4x4.Frustum(l, r, b, t, n, f);

        _camera.projectionMatrix = P;
        _camera.transform.rotation = Quaternion.LookRotation(-vn, vu);
    }
}
