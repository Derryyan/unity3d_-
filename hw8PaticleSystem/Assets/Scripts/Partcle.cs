using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePosition
{
    public float radius = 0f, angle = 0f, time = 0f;
    public CirclePosition(float radius, float angle, float time)
    {
        this.radius = radius;  
        this.angle = angle;    
        this.time = time;      
    }
}
public class Partcle : MonoBehaviour
{

    private ParticleSystem particleSystem;  
    private ParticleSystem.Particle[] particles; 
    private CirclePosition[] circle; 
    public int count = 10000;      
    public float size = 0.03f;      
    public float minRadius = 3f;  
    public float maxRadius = 4f; 
    public bool clockwise = true;   
    public float speed = 2f;        
    public float pingPong = 0.02f;  
    void Start()
    {   
        particles = new ParticleSystem.Particle[count];
        circle = new CirclePosition[count];

        particleSystem = this.GetComponent<ParticleSystem>();
        particleSystem.startSpeed = 0;            
        particleSystem.startSize = size;          
        particleSystem.loop = false;
        particleSystem.maxParticles = count;      
        particleSystem.Emit(count);               
        particleSystem.GetParticles(particles);
        RandomlySpread();  
    }

    void RandomlySpread()
    {
        for (int i = 0; i < count; ++i)
        {   
            float midRadius = (maxRadius + minRadius) / 2;
            float minRate = Random.Range(1.0f, midRadius / minRadius);
            float maxRate = Random.Range(midRadius / maxRadius, 1.0f);
            float radius = Random.Range(minRadius * minRate, maxRadius * maxRate);

            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 180 * Mathf.PI;

            float time = Random.Range(0.0f, 360.0f);

            circle[i] = new CirclePosition(radius, angle, time);

            particles[i].position = new Vector3(circle[i].radius * Mathf.Cos(theta), 0f, circle[i].radius * Mathf.Sin(theta));
        }

        particleSystem.SetParticles(particles, particles.Length);
    }

    // Update is called once per frame
    private int tier = 10;  
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if (clockwise)  
                circle[i].angle -= (i % tier + 1) * (speed / circle[i].radius / tier);
            else            
                circle[i].angle += (i % tier + 1) * (speed / circle[i].radius / tier);

            circle[i].angle = (360.0f + circle[i].angle) % 360.0f;
            circle[i].time += Time.deltaTime;
            circle[i].radius += Mathf.PingPong(circle[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;

            float angle = circle[i].angle / 180 * Mathf.PI;

            particles[i].position = new Vector3(circle[i].radius * Mathf.Cos(angle), 0f, circle[i].radius * Mathf.Sin(angle));
        }

        particleSystem.SetParticles(particles, particles.Length);
    }
}