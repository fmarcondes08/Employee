import { type FormEvent, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { EmployeesApi } from "../api/employeesApi";
import type { Employee } from "../types/employee";

const empty: Employee = { id: 0, firstName:"", lastName:"", email:"", position:"" };

export default function EmployeeForm() {
  const [model, setModel] = useState<Employee>(empty);
  const [err, setErr] = useState<string | null>(null);
  const navigate = useNavigate();
  const { id } = useParams();

  useEffect(() => {
    (async () => {
      if (id) {
        const e = await EmployeesApi.get(Number(id));
        setModel({ id: e.id, firstName: e.firstName, lastName: e.lastName, email: e.email, position: e.position });
      }
    })();
  }, [id]);

  const validate = (m: Employee) => {
    const errors: string[] = [];
    if (!m.firstName?.trim()) errors.push("First name required");
    if (!m.lastName?.trim()) errors.push("Last name required");
    if (!m.email?.trim() || !/^\S+@\S+\.\S+$/.test(m.email)) errors.push("Valid email required");
    if (!m.position?.trim()) errors.push("Position required");
    return errors;
    };

  const onSubmit = async (ev: FormEvent) => {
    ev.preventDefault();
    const errors = validate(model);
    if (errors.length) { setErr(errors.join("; ")); return; }
    try {
      if (id) await EmployeesApi.update(model);
      else    await EmployeesApi.create(model);
      navigate("/");
    } catch (e: any) {
      setErr(e.message);
    }
  };

  return (
    <div style={{maxWidth: 600, margin: "20px auto"}}>
      <h2>{id ? "Edit" : "New"} Employee</h2>
      {err && <p style={{color:"crimson"}}>{err}</p>}
      <form onSubmit={onSubmit} style={{display:"grid", gap:10}}>
        <input placeholder="First name" value={model.firstName}
               onChange={e => setModel(m => ({...m, firstName: e.target.value}))} />
        <input placeholder="Last name" value={model.lastName}
               onChange={e => setModel(m => ({...m, lastName: e.target.value}))} />
        <input placeholder="Email" value={model.email}
               onChange={e => setModel(m => ({...m, email: e.target.value}))} />
        <input placeholder="Position" value={model.position}
               onChange={e => setModel(m => ({...m, position: e.target.value}))} />
        <div style={{display:"flex", gap:10}}>
          <button type="submit">Save</button>
          <button type="button" onClick={() => navigate("/")}>Cancel</button>
        </div>
      </form>
    </div>
  );
}