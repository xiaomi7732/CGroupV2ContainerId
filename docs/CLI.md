# Example Utilities

By using the library, it is easy to build some utilities.

* Public docker image to detect container id:

    ```shell
    docker pull saars/cid
    docker run saars/cid
    ```

Output:

> Container Id: 7f1477ac7aa29f3e52d8d4f25632e9df461a3855cc8cd8ad071ad94181381215

* Inspect logs from the worker in Kubernetes Cluster:

  * Deploy `saars/cid-worker` into a Kubernetes cluster.
  * Check the logs of the pod: `kubectl logs <podName>`

    ```shell
    info: CodeWithSaar.Extensions.ContainerId.CGroupV1ContainerIdProvider[0] No container id matched.
    info: CodeWithSaar.Extensions.ContainerId.CGroupV2ContainerIdProvider[0] Matched. Value: 01d1ad1a7b528295f2d03619b35f995be9ddddcfd2a83c013df129aa6cc4d332
    info: CodeWithSaar.ContainerId.Worker.Worker[0] Container Id: 01d1ad1a7b528295f2d03619b35f995be9ddddcfd2a83c013df129aa6cc4d332. Wait for 10 seconds.
    ```

    * Notice, in that case, the first provider missed the container since it doesn't exist. But the second provider got it.
