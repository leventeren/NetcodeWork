using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkController : NetworkBehaviour
{
    #region PUBLIC
    public float moveSpeed = 5f;
    #endregion

    #region PRIVATE
    private Rigidbody rb;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        if (!IsOwner) return;

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _movePosition = new Vector3(_horizontal, 0f, _vertical) * moveSpeed * Time.deltaTime;
        Vector3 _newMovePosition = rb.position + rb.transform.TransformDirection(_movePosition);

        //transform.Translate(_move, Space.Self);
        rb.MovePosition(_newMovePosition);
    }
}
