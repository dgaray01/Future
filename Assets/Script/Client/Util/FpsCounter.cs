using System;
using Unity.Netcode;

public class FpsCounter : NetworkBehaviour {
    
    private float t;
    private long lastTicks = DateTime.Now.Ticks;
    private int count;
    private int frames;

    public override void OnNetworkSpawn() {
        if (!this.IsClient) OnDestroy();
    }

    public void Update () {
        long ticks = DateTime.Now.Ticks;
        this.t += (ticks - this.lastTicks);
        this.lastTicks = ticks;
        this.count++;
        
        if (this.t >= 10000000) {
            this.frames = this.count;
            this.count = 0;
            this.t %= 10000000;
        }
    }
    
    public int GetFps() {
        return this.frames;
    }
}
