namespace GeometryLibrary

module Geometry = 
    type Point = {X : float; Y : float} 

    let private Area a b c = 
        (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)

    let private BoundBox a b c d = 
        let a', b' = min a b, max a b
        let c', d' = min c d, max c d
        max a' c' <= min b' d'

    let Checker a b c d =
        BoundBox a.X b.X c.X d.X &&
        BoundBox a.Y b.Y c.Y d.Y &&
        Area a b c * Area a b d <= 0. &&
        Area c d a * Area c d b <= 0.