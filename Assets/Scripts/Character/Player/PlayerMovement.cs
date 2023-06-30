using UnityEngine;

namespace Character.Player
{
  public class PlayerMovement : Movement
  {
    protected override void Update()
    {
      base.Update();
      var horizontal = Input.GetAxisRaw("Horizontal");
      
      Move(horizontal);
      
      if (Input.GetKeyDown(KeyCode.Space) && canJump)
      {
        Jump();
      }
    }
  }
}
