namespace Tests

module Tests = 
    open System
    open GeometryLibrary.Geometry
    open NUnit.Framework

    [<Test>]
    let ``Simple intersect``() =
        let a = {X = 0.; Y = 0.}
        let b = {X = 0.; Y = 6.}
        let c = {X = -1.; Y = 0.}
        let d = {X = 3.;  Y = 2.}
        Assert.AreEqual(true, Checker a b c d)

    [<Test>]
    let ``No intersection``() = 
        let a = {X = 5.; Y = 7.}
        let b = {X = 10.; Y = 5.}
        let c = {X = -1.; Y = 0.}
        let d = {X = 3.;  Y = 2.}
        Assert.AreEqual(false, Checker a b c d)

    [<Test>]
    let ``Bounding box case with intersection``() = 
        let a = {X = -3.; Y = 3.}
        let b = {X = 2.; Y = -2.}
        let c = {X = 0.; Y = 0.}
        let d = {X = -5.;  Y = 5.}
        Assert.AreEqual(true, Checker a b c d)

    [<Test>]
    let ``Bounding box case without intersection``() = 
        let a = {X = -7.; Y = -7.}
        let b = {X = -2.; Y = -2.}
        let c = {X = 0.; Y = 0.}
        let d = {X = 5.;  Y = 5.}
        Assert.AreEqual(false, Checker a b c d)