import { useEffect, useState } from "react";
import { EmployeesApi } from "../api/employeesApi";
import type { Employee } from "../types/employee";
import { Link, useNavigate } from "react-router-dom";

export default function EmployeeList() {
  const [items, setItems] = useState<Employee[]>([]);
  const [loading, setLoading] = useState(true);
  const [err, setErr] = useState<string | null>(null);
  const navigate = useNavigate();

  const load = async () => {
    try {
      setLoading(true);
      setItems(await EmployeesApi.list());
      setErr(null);
    } catch (e: any) {
      setErr(e.message);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => { load(); }, []);

  const onDelete = async (id: number) => {
    if (!confirm("Delete employee?")) return;
    await EmployeesApi.remove(id);
    await load();
  };

  if (loading) return <p>Loading...</p>;
  if (err) return <p style={{color:"crimson"}}>Error: {err}</p>;

  return (
    <div style={{maxWidth: 900, margin: "20px auto"}}>
      <h2>Employees</h2>
      <button onClick={() => navigate("/new")}>+ New</button>
      <table style={{width:"100%", marginTop: 10, borderCollapse:"collapse"}}>
        <thead>
          <tr>
            <th style={{textAlign:"left"}}>Name</th>
            <th style={{textAlign:"left"}}>Email</th>
            <th style={{textAlign:"left"}}>Position</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {items.map(e => (
            <tr key={e.id}>
              <td>{e.firstName} {e.lastName}</td>
              <td>{e.email}</td>
              <td>{e.position}</td>
              <td style={{textAlign:"right"}}>
                <Link to={`/edit/${e.id}`}>Edit</Link>{" | "}
                <button onClick={() => onDelete(e.id)}>Delete</button>
              </td>
            </tr>
          ))}
          {items.length === 0 && (
            <tr><td colSpan={4}><em>No employees</em></td></tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
