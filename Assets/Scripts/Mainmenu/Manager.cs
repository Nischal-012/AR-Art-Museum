using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	[SerializeField]
	private Animator m_DropDownAnimator;
	[SerializeField]
	private Animator m_HelpAnimator;

	private bool m_Panel = false;
	private bool m_Help = false;

	public void Home()
	{
		m_Help = false;
		m_Panel = false;

		m_DropDownAnimator.SetBool("panel", m_Panel);
		m_HelpAnimator.SetBool("help", m_Help);

	}
	public void TogglePanel()
	{
		m_Panel = !m_Panel;
		m_DropDownAnimator.SetBool("panel", m_Panel);
	}
	public void Help()
	{

		m_Help = true;
		m_Panel = false;
		m_DropDownAnimator.SetBool("panel", m_Panel);
		m_HelpAnimator.SetBool("help", m_Help);
	}

	public void ARExplore()
	{
		SceneManager.LoadScene(1);
	}

	public void MarkerBasedExplore()
	{

		SceneManager.LoadScene(2);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
