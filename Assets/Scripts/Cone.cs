using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour {

	// Use this for initialization
	public int colliderSides = 18;
	int colliderHeightSegments = 1; // Not implemented yet
	float killRange = 10f;
	float coldRange = 75f;
	MeshCollider collider;
	Light light;

	void Start () {
        collider = GetComponent<MeshCollider>();
        light = GetComponent<Light>();
		GenerateCollider();
        // MeshFilter _meshFilter = GetComponent<MeshFilter>();
        // if (_meshFilter==null){
        //         Debug.LogError("MeshFilter not found!");
        //             return;
        // }
        //
        // Vector3 p0 = new Vector3(0,0,0) * 5;
        // Vector3 p1 = new Vector3(1,0,0) * 5;
        // Vector3 p2 = new Vector3(0.5f,0,Mathf.Sqrt(0.75f)) * 5;
        // Vector3 p3 = new Vector3(0.5f,Mathf.Sqrt(0.75f),Mathf.Sqrt(0.75f)/3) * 5;
        //
        // Mesh mesh = _meshFilter.sharedMesh;
        // if (mesh == null){
        //         _meshFilter.mesh = new Mesh();
        //             mesh = _meshFilter.sharedMesh;
        // }
        // mesh.Clear();
        // mesh.vertices = new Vector3[]{p0,p1,p2,p3};
        // mesh.triangles = new int[]{
		// 	0,1,2,
		// 		0,2,3,
		// 		2,1,3,
		// 		0,3,1
        // };
        //
        // mesh.RecalculateNormals();
        // mesh.RecalculateBounds();
        // ;
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator OnTriggerStay (Collider other) {
		Player player = other.GetComponent<Player>();
		if (player == null) {
			yield break;
		}

		yield return new WaitForFixedUpdate();
		float distance = Vector3.Distance(transform.position, other.transform.position);
		if(distance < light.range * killRange) {
			player.TransferHeat(0);
		}
		else if (distance > light.range * coldRange) {
			player.TransferHeat(1);
		}
		else {
			player.TransferHeat(2);
		}
	}


	void GenerateCollider () {
		float topRadius = 0f;

		float height = light.range;
		float bottomRadius = Mathf.Tan(light.spotAngle * .5f * Mathf.PI / 180f) * light.range;

		Mesh mesh = new Mesh();
		mesh.Clear();
		// print(Mathf.Tan(53f * Mathf.PI / 180f));


		int nbVerticesCap = colliderSides + 1;
#region Vertices

		// bottom + top + sides
		Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + colliderSides * colliderHeightSegments * 2 + 2];
		int vert = 0;
		float _2pi = Mathf.PI * 2f;

		// Bottom cap
		vertices[vert++] = new Vector3(0f, 0f, height);
		while( vert <= colliderSides )
		{
			float rad = (float)vert / colliderSides * _2pi;
			vertices[vert] = new Vector3(Mathf.Cos(rad) * bottomRadius, Mathf.Sin(rad) * bottomRadius, height);
			vert++;
		}

		// Top cap
		vertices[vert++] = new Vector3(0f, 0f, 0f);
		while (vert <= colliderSides * 2 + 1)
		{
			float rad = (float)(vert - colliderSides - 1)  / colliderSides * _2pi;
			vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, Mathf.Sin(rad) * topRadius, 0);
			vert++;
		}

		// Sides
		int v = 0;
		while (vert <= vertices.Length - 4 )
		{
			float rad = (float)v / colliderSides * _2pi;
			vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, Mathf.Sin(rad) * topRadius, 0);
			vertices[vert + 1] = new Vector3(Mathf.Cos(rad) * bottomRadius, Mathf.Sin(rad) * bottomRadius, height);
			vert+=2;
			v++;
		}
		vertices[vert] = vertices[ colliderSides * 2 + 2 ];
		vertices[vert + 1] = vertices[colliderSides * 2 + 3 ];
#endregion

#region Normales

		// bottom + top + sides
		Vector3[] normales = new Vector3[vertices.Length];
		vert = 0;

		// Bottom cap
		while( vert  <= colliderSides )
		{
			normales[vert++] = Vector3.down;
		}

		// Top cap
		while( vert <= colliderSides * 2 + 1 )
		{
			normales[vert++] = Vector3.up;
		}

		// Sides
		v = 0;
		while (vert <= vertices.Length - 4 )
		{
			float rad = (float)v / colliderSides * _2pi;
			float cos = Mathf.Cos(rad);
			float sin = Mathf.Sin(rad);

			normales[vert] = new Vector3(cos, 0f, sin);
			normales[vert+1] = normales[vert];

			vert+=2;
			v++;
		}
		normales[vert] = normales[ colliderSides * 2 + 2 ];
		normales[vert + 1] = normales[colliderSides * 2 + 3 ];
#endregion

#region UVs
		Vector2[] uvs = new Vector2[vertices.Length];

		// Bottom cap
		int u = 0;
		uvs[u++] = new Vector2(0.5f, 0.5f);
		while (u <= colliderSides)
		{
			float rad = (float)u / colliderSides * _2pi;
			uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
			u++;
		}

		// Top cap
		uvs[u++] = new Vector2(0.5f, 0.5f);
		while (u <= colliderSides * 2 + 1)
		{
			float rad = (float)u / colliderSides * _2pi;
			uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
			u++;
		}

		// Sides
		int u_sides = 0;
		while (u <= uvs.Length - 4 )
		{
			float t = (float)u_sides / colliderSides;
			uvs[u] = new Vector3(t, 1f);
			uvs[u + 1] = new Vector3(t, 0f);
			u += 2;
			u_sides++;
		}
		uvs[u] = new Vector2(1f, 1f);
		uvs[u + 1] = new Vector2(1f, 0f);
#endregion

#region Triangles
		int nbTriangles = colliderSides + colliderSides + colliderSides*2;
		int[] triangles = new int[nbTriangles * 3 + 3];

		// Bottom cap
		int tri = 0;
		int i = 0;
		while (tri < colliderSides - 1)
		{
			triangles[ i ] = 0;
			triangles[ i+1 ] = tri + 1;
			triangles[ i+2 ] = tri + 2;
			tri++;
			i += 3;
		}
		triangles[i] = 0;
		triangles[i + 1] = tri + 1;
		triangles[i + 2] = 1;
		tri++;
		i += 3;

		// Top cap
		//tri++;
		while (tri < colliderSides*2)
		{
			triangles[ i ] = tri + 2;
			triangles[i + 1] = tri + 1;
			triangles[i + 2] = nbVerticesCap;
			tri++;
			i += 3;
		}

		triangles[i] = nbVerticesCap + 1;
		triangles[i + 1] = tri + 1;
		triangles[i + 2] = nbVerticesCap;
		tri++;
		i += 3;
		tri++;

		// Sides
		while( tri <= nbTriangles )
		{
			triangles[ i ] = tri + 2;
			triangles[ i+1 ] = tri + 1;
			triangles[ i+2 ] = tri + 0;
			tri++;
			i += 3;

			triangles[ i ] = tri + 1;
			triangles[ i+1 ] = tri + 2;
			triangles[ i+2 ] = tri + 0;
			tri++;
			i += 3;
		}
#endregion

		mesh.vertices = vertices;
		mesh.normals = normales;
		mesh.uv = uvs;
		mesh.triangles = triangles;

		mesh.RecalculateBounds();
		collider.sharedMesh = mesh;
	}
}
