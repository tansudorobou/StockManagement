import { client } from "openapi/client";
import type { Route } from "./+types/home";
import { Form } from "react-router";

export function meta({}: Route.MetaArgs) {
  return [
    { title: "New React Router App" },
    { name: "description", content: "Welcome to React Router!" },
  ];
}

export async function loader(){
  const { data } = await client.GET("/inventories", {})

  return data
}

export async function action({
  request
}: Route.ActionArgs){
  // let formData = await request.formData();
  switch (request.method){
    case 'POST': {
      await client.POST("/inventories", {
        body: {
          itemMaster: {
            itemCode: "test",
            itemName: "test",
            classification: {
              item: "test",
              asset: "test"
            },
          },
          lotNo: "testlot",
          qty: 100
        }
      })
    }
  }
}

export default function Home({
  loaderData
}: Route.ComponentProps) { 

  return (<div>
    <div>Home</div>
    {loaderData?.map(d => (
      <div className="flex">
        <div>{d.lotNo}</div>
        <div>{d.itemMaster?.itemName}</div>
        <div>{d.qty}</div> 
      </div>
    ))}
    <Form method="POST">
      <button type="submit">Save</button>
    </Form>
    </div>)
}
