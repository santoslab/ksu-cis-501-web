using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Clock {
  private int t = 0;

  public void tick() { t = t + 1; }

  public int getTime() { return t; }
}
