using System;
using Microsoft.Xna.Framework;

public class Path
{
	public Path(params Vector2[] vertices)
	{
		this.vertices = vertices;
	}

	public Vector2 End => vertices[vertices.Length - 1];
	public int SectionCount => vertices.Length - 1;
	public Vector2 Start => vertices[0];

	public Vector2 GetLocationAtTime(float time)
	{
		if (time <= 0) return Start;
		else if (time >= SectionCount) return End;

		var section = (int)Math.Floor(time);
		var interPolationTime = time - section;

		var start = vertices[section];
		var end = vertices[section + 1];
		return (1 - interPolationTime) * start + (interPolationTime) * end;
	}

	private readonly Vector2[] vertices;
}