using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickHandler 
{
    public void HandleSingleLeftClick();

    public void HandleMultiLeftClick();

    public void HandleSingleRightClick();

    public void HandleMultiRightClick();
    public void HandleMiddleClick();

    public void HandleMiddleClickHold();
    public void HandleMiddleClickHoldReleased();
    public void Reset();

}
