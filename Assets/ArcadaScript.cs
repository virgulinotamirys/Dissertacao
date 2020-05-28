using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter))]
public class ArcadaScript : MonoBehaviour
{

    Mesh mesh;
    public List<Vector3> originalVertices;
    public List<Vector3> modifiedVertices;
    public List<Vector3> normals;


    public float collisionRadius = 500f;
    public float maximumDepression;

    public float force = 0.4f;

    Color[] colors;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.MarkDynamic();
        originalVertices = mesh.vertices.ToList();
        modifiedVertices = mesh.vertices.ToList();
        normals = mesh.normals.ToList();
        Debug.Log("Mesh Regenerated");
        colors = new Color[originalVertices.Count];
        

        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(1f, 1f, 1f, 1f);
        }

        for (int i = 14000; i < 15000; i++)
        {
            modifiedVertices[i] += Vector3.down * maximumDepression;
            colors[i] = Color.Lerp(Color.gray, Color.gray, originalVertices[i].y);
        }

        mesh.vertices = modifiedVertices.ToArray();
        mesh.RecalculateBounds();
        mesh.colors = colors;
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionStay(Collision collision)
    {
        /*foreach (var contact in collision.contacts)
        {
            var worldPos4 = this.transform.TransformPoint(contact.point);
            this.transform.worldToLocalMatrix * contact.point;
            var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);
            for (int i = 0; i < modifiedVertices.Count; ++i)
            {
                var distance = (worldPos - (modifiedVertices[i] + Vector3.down * maximumDepression)).magnitude;
                if (distance < collisionRadius)
                {
                    var newVert = originalVertices[i] - (normals[i] * force) * maximumDepression;
                    modifiedVertices.RemoveAt(i);
                    modifiedVertices.Insert(i, newVert);
                }
            }
            mesh.SetVertices(modifiedVertices);
        }*/

        int index = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Dropdown>().value;
        Debug.Log(index);

        if (index.Equals(0))
        {
       
            foreach (var contact in collision.contacts)
            {
                var worldPos4 = this.transform.TransformPoint(contact.point);
                var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);
                List<Color> colors = mesh.colors.ToList();
               
                for (int i = 0; i < modifiedVertices.Count; ++i)
                {
                    var distance = (worldPos - (modifiedVertices[i] + Vector3.down * maximumDepression)).magnitude;
                    if (distance < collisionRadius)
                    {
                        var newVert = originalVertices[i] - (normals[i] * force) * maximumDepression;
                        modifiedVertices.RemoveAt(i);
                        modifiedVertices.Insert(i, newVert);
                        colors[i] = new Color(1f, 1f, 1f, 1f);
                    }
                }
                mesh.SetVertices(modifiedVertices);
                mesh.colors = colors.ToArray();
                Debug.Log("Próxima etapa.");
               
            }
            
        }
        else if (index.Equals(1))
        {
            
            foreach (var contact in collision.contacts)
            {
                var worldPos4 = this.transform.TransformPoint(contact.point);
                var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);
                List<Color> colors = mesh.colors.ToList();
                for (int i = 0; i < modifiedVertices.Count; ++i)
                {
                    var distance = (worldPos - (modifiedVertices[i] + Vector3.down * maximumDepression)).magnitude;
                    if (distance < collisionRadius)
                    {
                        var newVert = originalVertices[i] - (normals[i] * force) * maximumDepression;
                        modifiedVertices.RemoveAt(i);
                        modifiedVertices.Insert(i, newVert);
                        colors[i] = new Color(1f, 1f, 1f, 1f);
                    }
                }
                mesh.SetVertices(modifiedVertices);
                mesh.colors = colors.ToArray();
                Debug.Log("Próxima etapa.");

            }
        }
        else if (index.Equals(2))
        {
            
            foreach (var contact in collision.contacts)
            {
                var worldPos4 = this.transform.TransformPoint(contact.point);
                var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);
                List<Color> colors = mesh.colors.ToList();
                for (int i = 0; i < modifiedVertices.Count; ++i)
                {
                    var distance = (worldPos - (modifiedVertices[i] + Vector3.up * maximumDepression)).magnitude;
                    if (distance < collisionRadius)
                    {
                        var newVert = originalVertices[i] + (normals[i] * force);
                        modifiedVertices.RemoveAt(i);
                        modifiedVertices.Insert(i, newVert);
                        colors[i] = new Color(1f, 1f, 1f, 1f);
                    }
                }

                mesh.SetVertices(modifiedVertices);
                mesh.colors = colors.ToArray();
                Debug.Log("Próxima etapa.");
            }
        }
        else
        {
            Debug.Log("Procedimento finalizado");

        }

    }

   

    /*void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Touchable")
        {
            Debug.Log("Hit in object");
            hit.rigidbody.AddForce(transform.forward * force);
        }
    }*/
}
